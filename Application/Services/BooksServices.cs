﻿using Application.ViewModels;
using Domain.Models;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class BooksServices
    {
        private AppDbContext _context;
        public BooksServices(AppDbContext context)
        {
            _context = context; 
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
        public List<Book> GetAllBooks() => _context.Books.ToList();

        public Book GetBookById (int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId);

        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }
        public void DeleteBook(int bookId)
        {
            var _books = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if( _books != null )
            {
                _context.Books.Remove(_books);
                _context.SaveChanges();
            }
        }
    }
}
