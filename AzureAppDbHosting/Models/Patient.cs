using System;
using System.Collections.Generic;

namespace AzureAppDbHosting.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Notification {  get; set; }
}
