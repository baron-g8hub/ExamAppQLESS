using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Common.Models
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class SCCNumberMaskAttribute : ValidationAttribute
    {
        // Internal field to hold the mask value.
        readonly string _mask;

        public string Mask
        {
            get { return _mask; }
        }

        public SCCNumberMaskAttribute(string mask)
        {
            _mask = mask;
        }

        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                string phoneNumber = (string)value;
                if (this.Mask != null)
                {
                    if (phoneNumber != null)
                    {
                        return MatchesMask(this.Mask, phoneNumber);
                    }
                }
            }
            return false;
        }

        // Checks if the entered phone number matches the mask.
        public bool MatchesMask(string mask, string phoneNumber)
        {
            if (mask.Length != phoneNumber.Trim().Length)
            {
                // Length mismatch.
                return false;
            }
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] == 'd' && char.IsDigit(phoneNumber[i]) == false)
                {
                    // Digit expected at this position.
                    return false;
                }
                if (mask[i] == '-' && phoneNumber[i] != '-')
                {
                    // Spacing character expected at this position.
                    return false;
                }
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, this.Mask);
        }


    }
}
