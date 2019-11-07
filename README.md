## Hangfire-MongoDB

Boş bir mvc projesinde Hangfire kütüphanesi kullanılarak arkaplanda çalışacak iş parçacıkları oluşturulup, bu iş parçacıkları çalıştıkça tutulacak kayıtar için MongoDB kullanılmıştır.

Visual Studio Package Manager Console ile indirilmesi gereken paketler:
> PM> Install-Package Hangfire.Core
 PM> Install-Package Hangfire.SqlServer
PM> Install-Package Hangfire.AspNet
PM> Install-Package Hangfire.Mongo
