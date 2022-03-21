//-----------------------------------------------------------------------
// <copyright file="Person.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Filip Vujeva</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.FilipVujeva.Contracts.Entities
{
    /// <summary>
    /// Person entity, represents smallest entity in hierarchy and has just the basic attributes.
    /// </summary>
    public class Person
    {
        /// <summary name = "Id"> Gets or sets Id.</summary>
        public int Id { get; set; }

        /// <summary name = "FirstName"> Gets or sets FirstName parameter.</summary>
        public string? FirstName { get; set; }

        /// <summary name = "LastName"> Gets or sets LastName parameter.</summary>
        public string? LastName { get; set; }

        /// <summary name = "Adress"> Gets or sets Adress parameter.</summary>
        public Adress? Adress { get; set; }
    }
}
