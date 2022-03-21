//-----------------------------------------------------------------------
// <copyright file="PersonDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Filip Vujeva</author>
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.Contracts.Dtos
{
    /// <summary>
    /// DTO for person Entity, used in POST requests in PeopleController.
    /// </summary>
    public class PersonDTO
    {
        /// <summary name = "FirstName"> Gets or sets FirstName parameter in DTO object.</summary>
        [Required(ErrorMessage ="You have to provide First Name")]
        [StringLength(20)]
        public string? FirstName { get; set; }

        /// <summary name = "LastName"> Gets or sets LastName parameter in DTO object.</summary>
        [Required(ErrorMessage = "You have to provide Last Name")]
        [StringLength(100)]
        public string? LastName { get; set; }

        /// <summary name = "LastName"> Gets or sets Adress parameter in DTO object.</summary>
        [Required(ErrorMessage = "You have to provide Adress")]
        public Adress? Adress { get; set; }
    }
}
