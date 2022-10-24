# ContactApp

Uygulamanın Temel görevi : 
  Rehbere kişi ekleyebilir, silebilir, güncelleyebilir; 
  Kişilere iletişim bilgisi ekleyebilir, silebilir, güncelleyebilir;
  Rapor talebinde bulunarak, arka planda raporları Excel Dosyası Olarak hazırlatabilir, hazırlanan ya da hazırlanmakta olan raporları görüntüleyebilirsiniz.
  
  
# Servisler
  * Core Service
  * Contact Service
  * Report Service
  * Backgrount Service
  * API Gateway Service
  
# Kullanılan Teknolojiler
* .Net Core 5.0
* Kafka Message Broker
* Ocelot
* Auto Mapper
* Autofac
* FluentValidation
* EntityFrameworkCore (PostgreSQL)
* Swashbuckle Swagger
* Newtonsoft
* EPPlus (Excel)
* Migration

# Proje Kullanım Klavuzu
Proje temelde 4 servisten oluşup, bütün servislerin altyapısını oluşturan Core       katmanı ile desteklenmektedir.

Projeyi indirdikten sonra 5000, 5001 , 5002 portlarında web servisler çalışacaktır.

Projede Message Broker olarak Kafka Kullanıldığından dolayı, Kafka ve zookeper sunucusunuz ayakta olmalıdır.

Kafkanın çalışacağı port proje de 9092 olarak ayarlıdır.

Kafkanın Produce ve Consume Yapacağı topic default olarak reportApplies adlı topic olacaktır. Kod içerisinde eğer o topic yoksa oluşturacak kod hazır bulunur.

Veritabanı olarak Postgre SQL kullanılmış olup örnek migration kodları proje içerisindedir. istenirse yeni migration oluşturabilir ya da mevcut üzerinden database update işlemi yapabilirsiniz.

Contact Service ve Report Service Kendilerine ait farklı DB leri vardır.

Startup Project olarak APIGateway, Contact Web API, Report Web API ve Background service seçilidir. (bir sebebten bu ayar size gelmezse lütfen bu şekilde ayarlayın)

# ####Önemli Notlar####
endpointlere, ocelot ile oluşturulan APIGateway ile atabileceğiniz gibi kendi servisleri üzerinden istek atabilirsiniz. herhangi bir cors önlemi alınmadı.

Rapor sisteminde Apply işleminde ki location ZORUNLU DEĞİLDİR. eğer gönderilmezse bütün şehirleri kapsayacak şekilde bir rapor üretir. Eğer spesifik bir şehir verilirse, sadece o şehir için rapor hazırlayıp excel üretecektir.


Bir Problem Yaşanması Halinde Linkedin üzerinden ulaşabilirsiniz.
https://www.linkedin.com/in/ulasmuezzinoglu
    
    
