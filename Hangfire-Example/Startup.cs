using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using System.Collections.Generic;
using System.Diagnostics;
using Hangfire.Mongo;

[assembly: OwinStartup(typeof(Hangfire_Example.Startup))]

namespace Hangfire_Example
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            var migrationOptions = new MongoMigrationOptions
            {
                Strategy = MongoMigrationStrategy.Migrate,
                BackupStrategy = MongoBackupStrategy.Collections
            };
            var storageOptions = new MongoStorageOptions
            {
                MigrationOptions = migrationOptions
            };
            
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMongoStorage("mongodb://localhost", "Hangfirewithmongodb", storageOptions); //Hangfirewithmongodb => Database ismi

            app.UseHangfireServer();
            app.UseHangfireDashboard();
            
            BackgroundJob.Enqueue(() => Baslangic()); //Başlangıçta tek sefer çalışacak iş parçacığı
            RecurringJob.AddOrUpdate(() => Dakikalik(), Cron.Minutely); //Her dakika çalışacak iş parçacığı
        }

        public void Baslangic()
        {
            Debug.WriteLine("Başlangıç");
        }
        public void Dakikalik()
        {
            Debug.WriteLine("Dakika");
        }
    }
}

