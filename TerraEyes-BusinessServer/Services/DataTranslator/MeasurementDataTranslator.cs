﻿using System;
using System.Globalization;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.Services.DataValidator;

namespace TerraEyes_BusinessServer.Services.DataTranslator
{
    public class MeasurementDataTranslator : IMeasurementDataTranslator
    {
        private readonly IDataValidatorService _dataValidatorService;
        
        public MeasurementDataTranslator()
        {
            _dataValidatorService = new DataValidatorService();
        }

        public void TranslateRawData(MeasurementRawInput input)
        {
            string data = input.data;

            string hexTemp = data[..4];
            string hexHumid = data[4..8];
            string hexCo2 = data[8..12];
            string hexPir = data[12..16];
            string hexLight = data[16..20];
            string hexServo = data[21..22];

            double temp = HexToDouble(hexTemp) / 10;
            double humid = HexToDouble(hexHumid) / 10;
            double co2 = HexToDouble(hexCo2);
            double pir = HexToDouble(hexPir);
            double light = HexToDouble(hexLight);

            bool servo = HexToBool(hexServo);

            DateTime ts = new DateTime(DateTime.UnixEpoch.Ticks)
                .AddHours(2)
                .AddMilliseconds(input.ts);

            string timeStamp = ts.ToString("yyyy-MM-ddTHH':'mm':'ss.fffZ");

            Measurement measurement = new Measurement
            {
                Eui = input.Eui,
                Temperature = temp,
                Humidity = humid,
                CarbonDioxide = (int) co2,
                Activity = (int) pir,
                Lumen = light,
                Timestamp = timeStamp,
                ServoMoved = servo
            };

            _dataValidatorService.ValidateMeasurementData(measurement);
        }

        private double HexToDouble(string hex)
        {
            Int16 number = Int16.Parse(hex, NumberStyles.HexNumber);
            string bytes = Convert.ToString(number, 2).PadLeft(16, '0');
            
            char[] binary = bytes.ToCharArray();
            double total = 0;

            int multiplier = 15;

            for (int i = 0; i < binary.Length; i++)
            {
                int value = int.Parse(binary[i].ToString());
                if (i == 0 && binary[i].Equals('1'))
                {
                    total += value * Math.Pow(2, multiplier) * -1;
                    multiplier--;
                }
                else
                {
                    total += value * Math.Pow(2, multiplier);
                    multiplier--;
                }
            }
            return total;
        }

        private bool HexToBool(string hex)
        {
            int number = int.Parse(hex, NumberStyles.HexNumber);
            string bytes = Convert.ToString(number, 2);
            char[] binary = bytes.ToCharArray();

            bool servo = binary[0].Equals('1');

            return servo;
        }
        
    }
}