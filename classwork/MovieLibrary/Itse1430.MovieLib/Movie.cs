﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Itse1430.MovieLib
{
    
    /// <summary>Represents movie data.</summary>
    public class Movie : IValidatableObject
    {
        #region Properties

        //Properties expose data of class as needed
        //Can be backed by fields but not required
        //Can be read, written or both - up to developer

        public int Id { get; set; }

        /// <summary>Gets or sets the title of the movie.</summary>
        [RequiredAttribute(AllowEmptyStrings = false)]
        public string Title
        {
            //null coalescing
            // !String.IsNullOrEmpty(_title) ? _title : ""
            //get { return _title ?? ""; }
            get => _title ?? "";
            set => _title = value;
            //set { _title = value; }
        }

        /// <summary>Gets or sets the description of the movie.</summary>
        public string Description
        {
            //get { return _description ?? ""; }
            //set { _description = value; }
            get => _description ?? "";
            set => _description = value;
        }

        /// <summary>Gets or sets the rating of the movie.</summary>
        [Required(AllowEmptyStrings = false)]
        public string Rating
        {
            //get { return _rating ?? ""; }
            //set { _rating = value; }
            get => _rating ?? "";
            set => _rating = value;
        }

        /// <summary>Gets or sets the release year.</summary>      
        [Display(Name = "Release Year")]
        [Range(1900,Int32.MaxValue, ErrorMessage = "Release year must be >= 1900")]
        public int ReleaseYear { get; set; } = 1900; //Auto property

        //Full property
        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}

        /// <summary>Gets or sets the run length.</summary>
        [RangeAttribute(0,Int32.MaxValue, ErrorMessage = "Run length must be >= 0")]
        public int RunLength { get; set; }
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}

        public bool HasSeen { get; set; }
        //{
        //    get { return _hasSeen; }
        //    set { _hasSeen = value; }
        //}

        //Value is 1939, read only, public
        //public int ReleaseYearForColor { get; } = 1939;

        //Constant field
        public const int ReleaseYearForColor = 1939;
        //public readonly int ReleaseYearForColor = 1939;

        /// <summary>Determines if a movie is B&W.</summary>
        public bool IsBlackAndWhite
            => ReleaseYear <= ReleaseYearForColor;

        //public bool IsBlackAndWhite
        //{
        //    //Calculated property, no backing field
        //    //Just calculating a value
        //    get => ReleaseYear <= ReleaseYearForColor; 
        //    //Not settable by anyone
        //    //set { }
        //}

        //Mixed accessibility - property must be most visible
        [Obsolete("Do not use", true)]
        public string TestAccessibility
        {
            //Single accessor can be more restrictive
            get { return ""; }

            //Not writable outside class
            private set { }
        }
        #endregion

        public override string ToString ()
            => $"{Title} ({ReleaseYear})";
        
        /// <summary>Validates the movie.</summary>
        /// <returns>An error message if validation fails or empty string otherwise.</returns>
        //public string Validate ()
        //{
        //    //`this` is implicit first parameter, represents instance
        //    //this.title == title

        //    //Name is required
        //    if (String.IsNullOrEmpty (this.Title))
        //        return "Title is required";

        //    //Release year >= 1900
        //    if (ReleaseYear < 1900)
        //        return "Release Year must be >= 1900";

        //    //Run length >= 0
        //    if (RunLength < 0)
        //        return "Run Length must be >= 0";

        //    //Rating is required
        //    if (String.IsNullOrEmpty (Rating))
        //        return "Rating is required";

        //    return "";
        //}

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            return Enumerable.Empty<ValidationResult> ();
            //Iterator syntax
            //var results = new List<ValidationResult> ()

            //Release year >= 1900
                //results.Add(new ValidationResult("Release Year must be >= 1900"));
               

            //Run length >= 0
                //results.Add(new ValidationResult("Run Length must be >= 0"));
               
            //Rating is required
            //if (String.IsNullOrEmpty (Rating))
                //results.Add(new ValidationResult( "Rating is required"));
                //yield return new ValidationResult ("Release Year must be >= 1900");

            //return results;
        }
#if DEBUG
        private void Foo ()
        {

        }
#endif
        #region Private Members

        //Fields - data to be stored
        //Never make fields public!!
        private string _title = "";
        private string _description = "";
        private string _rating = "";

        //private int _releaseYear = 1900;
        //private bool _hasSeen;
        //private int _runLength;
        //private readonly int _releaseYearForColor = 1939;
        #endregion
    }

}
