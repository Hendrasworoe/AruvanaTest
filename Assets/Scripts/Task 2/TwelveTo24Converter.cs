using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TwelveTo24Converter : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _printText;

    private TimeSpan _time;
    private string _meridiem;

    private bool InputIsValid(string inputString)
    {
        if (inputString.Length < 2) // input to short
        {
            return false;
        }

        _meridiem = inputString.Substring(inputString.Length - 2);
        if (!(_meridiem.Equals("AM") || _meridiem.Equals("PM"))) // if invalid meridiem
        {
            return false;
        }

        string time_string = inputString.Substring(0, inputString.IndexOf(_meridiem));
        string format = "g";
        if (TimeSpan.TryParseExact(time_string, format, CultureInfo.InvariantCulture, TimeSpanStyles.AssumeNegative, out _time))
        {
            if (_time.Hours > 12) // if hour exceed 12, input is invalid
            {
                return false;
            }

            return true; // the input is valid
        }

        return false; // the time is invalid
    }

    private string ConverTo24()
    {
        string result = _time.ToString();

        if (_meridiem.Equals("AM") && _time.Hours == 12)
        {
            result = String.Concat("00", result.Substring(2));
        }

        if (_meridiem.Equals("PM") && _time.Hours != 12)
        {
            int hour24 = _time.Hours + 12;
            result = String.Concat(hour24, result.Substring(2));
        }

        return result;
    }

    public void Print24Format()
    {
        // reset time
        _time = new TimeSpan();
        _meridiem = string.Empty;

        string input_string = _inputField.text;

        if (InputIsValid(input_string))
        {
            _inputField.text = String.Concat(_time.ToString(), _meridiem); // Input field correction

            _printText.text = ConverTo24();
        }
        else
        {
            _printText.text = "Please enter a valid 12 hours format with capitalize time";
        }
    }
}
