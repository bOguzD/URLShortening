# UrlShortening

Url kýsaltma projesi

# GetUrl Metodu

Bu metot, kýsa URL'yi almak için GET isteði yapar.
Girilen ShortUrl parametresinin karþýlýðý bulunursa otomatik olarak o sayfaya yönlendirme iþlemi yapýlýr.


Endpoint
	
	GET /GetUrl

Query Parametreleri

	ShortUrl: "Kýsa URL".

Baþarý Durumu
	
	200 OK: Kýsa URL baþarýyla bulundu. Uzun URL'e yönlendirilir.

Hata Durumu
	
	404 Not Found: Kýsa URL bulunamadý.

Örnek Kullaným
	
	GET /GetUrl?ShortUrl=myShortUrl


# CreateShortUrl Metodu


Bu metot, kýsa URL oluþturmak için POST isteði yapar.

	Sadece URL parametresi yazýlýrsa:
		Kýsa URL'in sonuna eklenen kod sistem tarafýndan otomatik olarak atanýr.

	CustomUrlShortCode parametresi boþ geçilmezse:
		Kullaný tarafýndan girilen kod kýsaltýlan URL'in sonuna eklenir.

Endpoint

	POST /CreateShortUrl

Request Body

	{
		"URL": "https://example.com",
		"CustomUrlShortCode": "myCustomCode"
	}

Baþarý Durumu

	200 OK: Kýsa URL baþarýyla oluþturuldu.

Hata Durumu

	400 Bad Request: Geçersiz istek veya hata.

Örnek Kullaným

	POST /CreateShortUrl
	Content-Type: application/json
	
	{
	  "URL": "https://example.com",
	  "CustomUrlShortCode": "myCustomCode"
	}


# Database

Database olarak SQLite kullanýlmýþtýr.
