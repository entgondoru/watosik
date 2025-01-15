using MediatR;
using Watosik.Application.DataTransferObjects;

namespace Watosik.Application.Queries.GetAllPhoneBookContacts
{
    public class GetAllPhoneBookContactsQuery : IRequest<IEnumerable<phone_book_contactDto>>
    {

    }
}
