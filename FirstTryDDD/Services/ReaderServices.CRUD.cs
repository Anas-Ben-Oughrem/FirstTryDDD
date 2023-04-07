using FirstTryDDD.API.DTOs.ReaderDTOs;
using FirstTryDDD.API.Services.AbstractionServices;
using FirstTryDDD.Core.AggregateModels.ReaderAggregate;
using FirstTryDDD.Infrastructure.Data;
using FirstTryDDD.SharedKarnel.Enums;
using FirstTryDDD.SharedKarnel.Extensions;
using FirstTryDDD.SharedKarnel.Models;
using FirstTryDDD.SharedKernel.Models;
using FirstTryDDD.SharedKernel.Services;
using Microsoft.EntityFrameworkCore;
using SCodes = FirstTryDDD.SharedKernel.Models.StatusCodes;

namespace FirstTryDDD.API.Services
{
    public class ReaderServicesCRUD : BaseServices
    {
        #region Local Variables + Constructor

        private readonly AppDbContext _context;
        public ReaderServicesCRUD(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Main Methods

        #region GetAllAsync
        public async Task<Response> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<Reader> readers = await _context.Reader.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

                return new GlobalResponse
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status200OK,
                    Object = PagedList<GetAllReadersResponse>.ToPagedList(readers.ToCastedList(r => new GetAllReadersResponse(r)), await _context.Reader.CountAsync(), pageNumber, pageSize)
                };
            }
            catch (Exception ex)
            {
                return GetException(ex);
            }

        }
        #endregion

        #region GetByIdAsync
        public async Task<Response> GetById(Guid id)
        {
            try
            {
                Reader reader = await _context.Reader.FirstOrDefaultAsync(a => a.Id == id);

                if (reader == null)
                    return new SimpleErrorResponse
                    {
                        Result = ResponseResult.Error,
                        Status = SCodes.Status404NotFound,
                        MsgException = "Cannot find this reader"
                    };

                return new GlobalResponse
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status200OK,
                    Object = new GetReaderByIdResponse(reader)
                };
            }
            catch (Exception ex)
            {
                return GetException(ex);
            }
        }
        #endregion


        #region PostAsync
        public async Task<Response> PostAsync(PostReaderRequest req)
        {
            try
            {
                DateTime today = DateTime.Now;

                Reader reader = new()
                {
                    Name = req.Name,
                    Email = req.Email,
                    Password = req.Password,
                    CreatedDate = today,
                    UpdatedDate = today,
                };

                _context.Reader.Add(reader);
                await _context.SaveChangesAsync();

                return new GlobalResponse
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status201Created,
                    Object = new PostReaderResponse(reader)
                };
            }
            catch (Exception ex)
            {
                return GetException(ex);
            }
        }
        #endregion


        #region PutAsync
        public async Task<Response> PutAsync(PutReaderRequest req)
        {
            try
            {
                Reader reader = await _context.Reader.FindAsync(req.Id);

                if (reader == null)
                    return new SimpleErrorResponse
                    {
                        Result = ResponseResult.Error,
                        Status = SCodes.Status404NotFound,
                        MsgException = "Cannot find this reader"
                    };

                reader.Name = GenericServices<string>.IsDefaultValue(req.Name) ? reader.Name : req.Name;
                reader.Email = GenericServices<string>.IsDefaultValue(req.Email) ? reader.Email : req.Email;
                reader.Password = GenericServices<string>.IsDefaultValue(req.Password) ? reader.Password : req.Password;

                reader.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return new GlobalResponse
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status200OK,
                    Object = new PutReaderResponse(reader)
                };
            }
            catch (Exception ex)
            {
                return GetException(ex);
            }
            #endregion
        }

        #region DeleteAsync
        public async Task<Response> DeleteAsync(Guid id)
        {
            try
            {

                Reader reader = await _context.Reader.FindAsync(id);

                if (reader == null)
                    return new SimpleErrorResponse
                    {
                        Result = ResponseResult.Error,
                        Status = SCodes.Status404NotFound,
                        MsgException = "Cannot find this reader"
                    };

                _context.Reader.Remove(reader);
                await _context.SaveChangesAsync();

                return new Response
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return GetException(ex);
            }
        }
        #endregion

        #endregion
    }
}
