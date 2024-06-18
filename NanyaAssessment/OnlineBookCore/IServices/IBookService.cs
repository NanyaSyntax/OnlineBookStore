using OnlineBookStore.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Core.IService
{
    public interface IBookService
    {
        Task<AddBookDTO> AddBookAsync(AddBookDTO bookDTO);
        Task<IEnumerable<BookDTO>> SearchBooksAsync(string query);
        Task<BookDTO> GetBookByIdAsync(string id);
    }
}
