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
    public class PublishersService
    { 
        private AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVm publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public List<Publisher> GetAll() => _context.Publishers.ToList();

        public Publisher GetPublisherById(int PublisherId) => _context.Publishers.FirstOrDefault(o => o.Id == PublisherId);
        
        public void ApdatePublisherById(int PublisherId, PublisherVm publisher)
        {
            var _publisher = _context.Publishers.FirstOrDefault(o => o.Id == PublisherId);
            if(_publisher != null)
            {
                _publisher.Name = publisher.Name;
            }
            _context.SaveChanges();
        }
        
        public void DeletePublisher(int PublisherId)
        {
            var publisher  = _context.Publishers.FirstOrDefault(o => o.Id == PublisherId);
            if(publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }

    }
}
