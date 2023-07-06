using Application.ViewModels;
using Domain.Models;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthorService
    {
        private AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVm author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public List<Author> GetAll() => _context.Authors.ToList();

        public Author GetAuthorById(int AuthorId) => _context.Authors.FirstOrDefault(o => o.Id == AuthorId);
        
        public void ApdateAuthorById(int AuthorId, AuthorVm author)
        {
            var _author = _context.Authors.FirstOrDefault(o => o.Id == AuthorId);
            if(author != null)
            {
                _author.FullName = author.FullName;
            }
            _context.SaveChanges();
        }
        
        public void DeleteAuthor(int AuthorId)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Id == AuthorId);
            if(author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }

    }
}
