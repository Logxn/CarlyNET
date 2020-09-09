using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarlyNET.Body.Response
{
    public class UpgradeOptions
    {
        [JsonProperty("lto_eligible_until")]
        public int LtoEligibleUntil { get; set; }
    }

    public class UsedFunctions
    {
        [JsonProperty("carcheck")]
        public int Carcheck { get; set; }

        [JsonProperty("coding")]
        public int Coding { get; set; }

        [JsonProperty("diagnostics")]
        public int Diagnostics { get; set; }

        [JsonProperty("parameter")]
        public int Parameter { get; set; }
    }

    public class DashboardState
    {
        [JsonProperty("adapter")]
        public int Adapter { get; set; }

        [JsonProperty("car")]
        public int Car { get; set; }

        [JsonProperty("coding")]
        public int Coding { get; set; }

        [JsonProperty("connection")]
        public int Connection { get; set; }

        [JsonProperty("diagnostics")]
        public int Diagnostics { get; set; }

        [JsonProperty("diagnostics_clearing")]
        public int DiagnosticsClearing { get; set; }

        [JsonProperty("discovery")]
        public int Discovery { get; set; }

        [JsonProperty("identification")]
        public int Identification { get; set; }

        [JsonProperty("obd")]
        public int Obd { get; set; }

        [JsonProperty("restore")]
        public int Restore { get; set; }

        [JsonProperty("signup")]
        public int Signup { get; set; }
    }

    public class Vehicle
    {
        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("build_year")]
        public string BuildYear { get; set; }

        [JsonProperty("car_make")]
        public int CarMake { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("dashboard_state")]
        public DashboardState DashboardState { get; set; }

        [JsonProperty("fuel_type")]
        public int FuelType { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }
    }

    public class SyncResponse
    {
        [JsonProperty("last_sync_at")]
        public int LastSyncAt { get; set; }

        [JsonProperty("last_used_adapter")]
        public int LastUsedAdapter { get; set; }

        [JsonProperty("registered_at")]
        public int RegisteredAt { get; set; }

        [JsonProperty("upgrade_options")]
        public UpgradeOptions UpgradeOptions { get; set; }

        [JsonProperty("used_functions")]
        public UsedFunctions UsedFunctions { get; set; }

        [JsonProperty("vehicles")]
        public List<Vehicle> Vehicles { get; set; }
    }
}
