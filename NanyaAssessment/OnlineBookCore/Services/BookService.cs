using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Core.IService;
using OnlineBookStore.Data.DTO;
using OnlineBookStore.Data.Repository.Interface;
using OnlineBookStore.Model.Entities;

namespace OnlineBookStore.Core.Services
{
    public class BookService : IBookService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddBookDTO> AddBookAsync(AddBookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);

            _unitOfWork.BookRepo.Add(book);
            _unitOfWork.Save();

            return _mapper.Map<AddBookDTO>(book);
        }

        public async Task<IEnumerable<BookDTO>> SearchBooksAsync(string query)
        {
            var books = await _unitOfWork.BookRepo.SearchAsync(
                b => b.Title.Contains(query) || b.Author.Contains(query)
            );

            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<BookDTO> GetBookByIdAsync(string id)
        {
            var book = _unitOfWork.BookRepo.GetByIdAsync(id);
            return _mapper.Map<BookDTO>(book);
        }
    }
}