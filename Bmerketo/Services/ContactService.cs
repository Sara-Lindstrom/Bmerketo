using Bmerketo.Contexts;
using Bmerketo.Models.Entities;
using Bmerketo.Models.ViewModels;

namespace Bmerketo.Services
{
    public class ContactService
    {
        private readonly DataContext _context;

        public ContactService(DataContext context)
        {
            _context = context;
        }

        public async Task RegisterContactFormAsync(ContactFormViewModel contactForm)
        {   
            if (contactForm is not null)
            {
                var _contactEntity = contactForm;
                await _context.Contacts.AddAsync(_contactEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
