# UrlShortening

Url k�saltma projesi

# GetUrl Metodu

Bu metot, k�sa URL'yi almak i�in GET iste�i yapar.
Girilen ShortUrl parametresinin kar��l��� bulunursa otomatik olarak o sayfaya y�nlendirme i�lemi yap�l�r.


Endpoint
	
	GET /GetUrl

Query Parametreleri

	ShortUrl: "K�sa URL".

Ba�ar� Durumu
	
	200 OK: K�sa URL ba�ar�yla bulundu. Uzun URL'e y�nlendirilir.

Hata Durumu
	
	404 Not Found: K�sa URL bulunamad�.

�rnek Kullan�m
	
	GET /GetUrl?ShortUrl=myShortUrl


# CreateShortUrl Metodu


Bu metot, k�sa URL olu�turmak i�in POST iste�i yapar.

	Sadece URL parametresi yaz�l�rsa:
		K�sa URL'in sonuna eklenen kod sistem taraf�ndan otomatik olarak atan�r.

	CustomUrlShortCode parametresi bo� ge�ilmezse:
		Kullan� taraf�ndan girilen kod k�salt�lan URL'in sonuna eklenir.

Endpoint

	POST /CreateShortUrl

Request Body

	{
		"URL": "https://example.com",
		"CustomUrlShortCode": "myCustomCode"
	}

Ba�ar� Durumu

	200 OK: K�sa URL ba�ar�yla olu�turuldu.

Hata Durumu

	400 Bad Request: Ge�ersiz istek veya hata.

�rnek Kullan�m

	POST /CreateShortUrl
	Content-Type: application/json
	
	{
	  "URL": "https://example.com",
	  "CustomUrlShortCode": "myCustomCode"
	}


# Database

Database olarak SQLite kullan�lm��t�r.
