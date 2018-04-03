using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        //if you need to add specific fields here from customer without poluting the original domain model do so here.
        public Customer Customer { get; set; }

    }
}