//-----------------------------------------------------------------------
// <copyright file="Adress.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Filip Vujeva</author>
//-----------------------------------------------------------------------

namespace Library.FilipVujeva.Contracts.Entities
{
    /// <summary>
    /// Adress entity.
    /// </summary>
    public class Adress
    {
        public int Id { get; set; }

        public Person Person { get; set; }
        /// <summary> Gets or sets Street.</summary>
        public string? Street { get; set; }

        /// <summary> Gets or sets City.</summary>
        public string? City { get; set; }

        /// <summary> Gets or sets Country.</summary>
        public string? Country { get; set; }
    }
}
