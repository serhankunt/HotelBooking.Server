# Otel Otomasyon Projesi

Otel otomasyonu, birden fazla otelin odalarının müşteri takibinin yapılabilmesini amaçlamaktadır. Oteller birer kullanıcı olarak, sistem yöneticisi tarafından tanımlanabilecektir. Her otel, kendi oda tanımlarını yapabilecektir. Oteller, müşterilerini çevirim dışı da tanımlayabileceği göz önünde bulundurularak, otellere oda durumlarını günleme izni verilmelidir. Sisteme üye olan normal kullanıcılar ise, otel ve oda tercihleri yaparak, odalara rezervasyon yaptırabilecektir. Sistem kullanıcısı, sisteme otelleri ve odalarını tanımlayacaktır.
-  Admin, otel sahipleri ve otel kullanıcıları olarak 3 rol oluşturulacak.
- Otel sahipleri oda tiplerini ve sayılarını belirtecek. 
-	Admin ve otel sahibi otellerdeki doluluk durumunu inceleyebilecek, admin tüm otelleri, otel sahipleri ise kendi otellerinin. Kullanıcılar ise otellerdeki rezerve edilebilir odaların sayısı 3’e düştüğünde oda ekranında görebilecek. Diğer türlü ekranda kullanıcıya bilgi verilmeyecek.
-	Kullanıcılar otel ve oda tercih ederek rezervasyon yapacak. Rezervasyon tamamlandığında mail adreslerine bilgilendirme gidecek. Son 24 saate kadar rezervasyonlarını iptal etmek seçenekleri mevcut olacak.
-	Otel sakinleri konaklamaları tamamlandığında otel ve oda için değerlendirme yapabilecek ve bu değerlendirme otel ve oda ekranlarında görüntülenebilecek. 50 kullanıcı değerlendirme sonucu ortalama puanı 2’nin altında olan internet sayfasında görüntülenmeyecek.
-Otel arama seçenekleri isme veya konuma göre olacak. Örneğin Ankara/Etimesgut, İstanbul/Esenyurt ya da X Otel, Y Otel.
-	Otel ücret ödeme ekranı iyzico ödeme entegrasyonu ile gerçekleşecek. Ödemeler TL bazında olacak.
-	Subscribe olanlara RabbitMQ kuyruk mesaj sistemi ile site içi bilgilendirme mesajları gönderilecek.


