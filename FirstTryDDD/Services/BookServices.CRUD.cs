using FirstTryDDD.API.DTOs.BookDTOs;
using FirstTryDDD.API.Services.AbstractionServices;
using FirstTryDDD.Core.AggregateModels.BookAggregate;
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
    public partial class BookServicesCRUD : BaseServices
    {
        #region Local Variables + Constructor

        private readonly AppDbContext _context;
        public BookServicesCRUD(AppDbContext context)
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
                IEnumerable<Book> Books = await _context.Book.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

                return new GlobalResponse
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status200OK,
                    Object = PagedList<GetAllBooksResponse>.ToPagedList(Books.ToCastedList(b => new GetAllBooksResponse(b)), await _context.Book.CountAsync(), pageNumber, pageSize)
                };
            }
            catch (Exception ex)
            {
                return GetException(ex);
            }

        }
        #endregion

        #region GetByIdAsync
        public async Task<Response> GetById(int id)
        {
            try
            {
                Book book = await _context.Book.FirstOrDefaultAsync(a => a.Id == id);

                if (book == null)
                    return new SimpleErrorResponse
                    {
                        Result = ResponseResult.Error,
                        Status = SCodes.Status404NotFound,
                        MsgException = "Cannot find this book"
                    };

                return new GlobalResponse
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status200OK,
                    Object = new GetBookByIdResponse(book)
                };
            }
            catch (Exception ex)
            {
                return GetException(ex);
            }
        }
        #endregion


        #region PostAsync
        public async Task<Response> PostAsync(PostBookRequest req)
        {
            try
            {
                DateTime today = DateTime.Now;

                Book book = new()
                {

                    CreatedDate = today,
                    UpdatedDate = today,
                };

                _context.Book.Add(book);
                await _context.SaveChangesAsync();

                return new GlobalResponse
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status201Created,
                    Object = new GetBookByIdResponse(book)
                };
            }
            catch (Exception ex)
            {
                return GetException(ex);
            }
        }
        #endregion


        #region PutAsync
        public async Task<Response> PutAsync(PutBookRequest req)
        {
            try
            {
                Book book = await _context.Book.FindAsync(req.Id);

                if (book == null)
                    return new SimpleErrorResponse
                    {
                        Result = ResponseResult.Error,
                        Status = SCodes.Status404NotFound,
                        MsgException = "Cannot find this author"
                    };

                book.Title = GenericServices<string>.IsDefaultValue(req.Title) ? book.Title : req.Title;
                book.Uri = GenericServices<string>.IsDefaultValue(req.Uri) ? book.Uri : req.Uri;
               

                book.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return new GlobalResponse
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status200OK,
                    Object = new PutBookResponse(book)
                };
            }
            catch (Exception ex)
            {
                return GetException(ex);
            }
        }
        #endregion


        #region DeleteAsync
        public async Task<Response> DeleteAsync(Guid id)
        {
            try
            {

                Book book = await _context.Book.FindAsync(id);

                if (book == null)
                    return new SimpleErrorResponse
                    {
                        Result = ResponseResult.Error,
                        Status = SCodes.Status404NotFound,
                        MsgException = "Cannot find this book"
                    };

                _context.Book.Remove(book);
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

