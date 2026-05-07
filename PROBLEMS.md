1.Gereksiz özellikler -> Karakter özelliklerinde target, attack ve damage gibi bazı karakter alt sınıflarının kullanmayacağı özellikler var. Bunların olması gereksiz kod karmaşıklığına yol açar.

2.Yeni bir tür eklemek gereksiz zordur -> Kodda sadece karakterler birbirine saldıracakmış gibi olduğu için sadece attack fonksiyonu var. Oyuna dövüşçü olmayan bir karakter eklediğimizde onun kodunu yazmak zor olur.

3.Tag sıkıntısı -> Oyunda oyuncu ve düşmanlara taglerle bakıyoruz ve bu en ufak hatada çökme riski taşır. Örnek : "Dusman" değil de "dusman" yazarsak sıkıntı çıkartabilir.

4.Yeni özellik ekleme zorluğu -> Sadece dusman veya dost için yeni bir özellik eklemeye kalkarsak tek bir class kullandığımız için o classa bu özelliği eklemek zorunda kalırız ve diğer karakterler de bundan etkilenir.

5.Her şey tek fonksiyonda -> Her şey attack fonksiyonu içinde gerçekleşiyor ve bu en ufak bir sıkıntıda çökme sorunu ve kodun anlaşılabilirliği ve okunabilirliğini etkiler.

AI ANALIZI

1. Açık/Kapalı Prensibinin (OCP) İhlali

Sorun: attack fonksiyonu tamamen if-else zincirlerine bağımlı. Oyuna "Boss" veya "Tüccar" gibi yeni bir karakter eklediğinde mevcut attack metodunu değiştirip yeni bir else if eklemek zorunda kalacaksın. Bu da kodun değiştirilmeye kapalı, yeni özelliklere açık olması kuralını bozar.

Çözebilecek Örüntü: Saldırı davranışlarını (saldıran, saldırmayan, farklı saldıran) birbirinden ayırıp esnekleştirmek için Strategy (Strateji) örüntüsü.

2. Tek Sorumluluk Prensibi (SRP) İhlali (God Class)

Sorun: charactersFeatures sınıfı hem karakterin verilerini tutuyor (can, hasar) hem de "Dost", "Düşman" ve "Obje"nin tüm farklı davranışlarını tek bir yerde yönetmeye çalışıyor. Bir sınıfın değişmek için yalnızca tek bir nedeni olmalıdır.

Çözebilecek Örüntü: Sorumlulukları doğru sınıflara dağıtmak ve her objenin kendi davranışını yönetmesini sağlamak için State (Durum) örüntüsü veya nesneleri alt sınıflara bölmek (Polymorphism).

3. "Magic String" Kullanımı ve Tip Güvenliği Eksikliği

Sorun: Karakterlerin kim olduğunu this.name == "Dusman" şeklinde string (metin) eşleşmeleriyle kontrol ediyorsun. Kodun bir yerinde yanlışlıkla "dusman" yazılırsa kod hata fırlatmaz, oyun sessizce bozulur.

Çözebilecek Örüntü: İsimlere dayalı string kontrolleri yerine gerçek nesne tipleri (örn: Dusman sınıfı) yaratmak için Factory Method (Fabrika Metodu).

4. Gereksiz Veri ve Bellek Yükü (Liskov Substitution İhlali)

Sorun: "Obje" isimli bir nesnenin (örneğin bir duvar veya ağaç) bir target'ı (hedefi) veya damage'i (hasarı) olamaz. Ancak aynı sınıfı kullandıkları için "Obje" nesneleri de bellekte gereksiz yere bu verileri taşımak zorunda kalıyor.

Çözebilecek Örüntü: Temel bir yapı (Interface/Abstract Class) oluşturup nesneleri kendi ihtiyaçlarına göre inşa eden Builder (İnşa Edici) örüntüsü veya özellik ayrımı için Decorator.

5. Esnek Olmayan Nesne Yaratımı

Sorun: Tüm nesneler aynı kurucu metot (constructor) ile yaratılıyor. İleride sadece düşmana özel bir özellik (örneğin Zırh) eklemek istersen, o özellik ile hiç alakası olmayan Dost ve Obje'nin de yaratım kodları patlayacaktır.

Çözebilecek Örüntü: Nesne yaratma işini (kimin neye ihtiyacı varsa ona göre yaratılmasını) bu sınıfın içinden çıkarıp başka bir yere devretmek için Factory Method veya Abstract Factory.

AI NE GORDU, BEN NE GORDUM?

-Benim TAG sıkıntısı dediğim soruna AI "Magic String" kullanımı dedi. Temelde aynı şeyden bahsettik. "Dusman" yerine "dusman" yazarsak sorun olur gibi.
-Benim Gereksiz Özellikler var dediğim kısma AI 2 yerde bahsetti. Liskov ihlali ve SRP ihlali kısımlarında.
-Benim yeni özellik eklemek zor oluyor dediğim sorunu AI Esnek olmayan Nesne Yaratımı olarak adlandırdı.
-Benim yeni bir tür ekleme zorluğu kısmını AI OCP ihlali olarak adlandırdı.

Temelde AI da ben de aynı sorunları gördük. Aralarında ufak tefek farklılıklar olsa da temelde hep aynı şeylerden bahsettik.

 

