using System;

namespace TerraEyes_BusinessServer.Models
{
    public class MeasurementRawInput
    {
        public String cmd { get; set; }
        public String Eui { get; set; }
        public long ts { get; set; }
        public bool ack { get; set; }
        public int fcnt { get; set; }
        public int port { get; set; }

        public String data { get; set; }
        /*
 * [DATA MEMORY ALLOCATION]
 * temp 16b
 * hum 16b
 * co2 16b
 * PIR 16b
 * light 16b unsigned
 * servo 1b
 */
    }
}