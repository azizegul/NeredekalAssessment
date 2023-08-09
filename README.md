# Hotel

Proje Code First mantığıyla oluşturulmuştur. 
Veritabanı olarak MSSQL ve MongoDb kullanılmıştır. 

* SQL ve MongoDb local üzerinden, RabbitMQ CloudAMQP üzerinden bağlanıp çalıştırılmıştır.
* Migration için herhangi bir işlem yapmanıza gerek yoktur. Contact projesi ayağa kalktığında database otomatik oluşacaktır.
### Structure

* Message Broker -> Rabbitmq
* Service Bus -> Mass Transit
* Databases -> MSSQL and MongoDb
* Open Doc -> Swagger

# Microservices

### Hotel Service
  - Host: `https://localhost:7273`

### Report Service
 - Host: `https://localhost:7038`


