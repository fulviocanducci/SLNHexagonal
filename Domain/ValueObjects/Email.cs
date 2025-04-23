using System;
using System.Text.RegularExpressions;
namespace Domain.ValueObjects
{
   public class Email
   {
      public string Value { get; }

      public Email(string value)
      {
         if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty.", nameof(value));

         if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            throw new ArgumentException("Invalid email format.", nameof(value));

         Value = value;
      }

      public override string ToString() => Value;
      public override bool Equals(object obj) => obj is Email other && Value == other.Value;
      public override int GetHashCode() => Value.GetHashCode();
   }
}
