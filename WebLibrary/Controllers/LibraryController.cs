using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SUT23LibraryProj.Models.DTOs;
using WebLibrary.Models;
using WebLibrary.Services;

namespace WebLibrary.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IBookService _bookService;

        public LibraryController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> LibraryIndex()
        {
            List<BookDTO> bookList = new List<BookDTO>();
            var response = await _bookService.GetAllBooks<ResponseDTO>();
            if (response != null && response.IsSuccess)
            {
                bookList = JsonConvert.DeserializeObject<List<BookDTO>>(Convert.ToString(response.Result));

            }
            return View(bookList);
        }

        public async Task<IActionResult> BookDetails(int id)
        {
            BookDTO bookDTO = new BookDTO();
            var response = await _bookService.GetBookByID<ResponseDTO>(id);
            if (response != null && response.IsSuccess)
            {
                BookDTO model = JsonConvert
                    .DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(model);

            }
            return View();
        }

        public async Task<IActionResult> AddBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(CreateBookDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.CreateBookAsync<ResponseDTO>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(LibraryIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateBookDetails(int id)
        {
            var response = await _bookService.GetBookByID<ResponseDTO>(id);
            if (response != null && response.IsSuccess)
            {
                UpdateBookInfoDTO model = JsonConvert.DeserializeObject<UpdateBookInfoDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBookDetails(UpdateBookInfoDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.UpdateBookAsync<ResponseDTO>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(LibraryIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateBookStock(int id)
        {
            var response = await _bookService.GetBookByID<ResponseDTO>(id);
            if (response != null && response.IsSuccess)
            {
                UpdateBookStockDTO model = JsonConvert.DeserializeObject<UpdateBookStockDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBookStock(UpdateBookStockDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.UpdateBookStockAsync<ResponseDTO>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(LibraryIndex));
                }
            }
            return View(model);
        }

            public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookService.GetBookByID<ResponseDTO>(id);
            if (response != null && response.IsSuccess)
            {
                BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost] // varför post och inte delete?
        public async Task<IActionResult> DeleteBook(BookDTO model)
        {
            var response = await _bookService.DeleteBookAsync<ResponseDTO>(model.BookID);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(LibraryIndex));
            }
            return NotFound();
        }
    }
}

