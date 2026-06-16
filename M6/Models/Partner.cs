using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6.Models;

public class Partner
{
    public int IdPartner { get; set; }

    public string PartnerType { get; set; } = "";

    public string PartnerName { get; set; } = "";

    public string DirectorFullName { get; set; } = "";

    public string DirectorLastname { get; set; } = "";

    public string DirectorFirstname { get; set; } = "";

    public string DirectorPatronymic { get; set; } = "";

    public string PhoneNumber { get; set; } = "";

    public string Email { get; set; } = "";

    public string Index { get; set; } = "";

    public string Region { get; set; } = "";

    public string City { get; set; } = "";

    public string Street { get; set; } = "";

    public string HouseNumber { get; set; } = "";

    public string Inn { get; set; } = "";

    public int Discount { get; set; }

    public string Rating { get; set; } = "";
}
