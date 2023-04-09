using System;
using System.Collections.Generic;

namespace CMPS278Backend.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Image { get; set; } = null!;

    public double Rating { get; set; }

    public string Genres { get; set; } = null!;

    public string Trailer { get; set; } = null!;

    public string Cast { get; set; } = null!;

    public string Credits { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public string Reviews { get; set; } = null!;
}
