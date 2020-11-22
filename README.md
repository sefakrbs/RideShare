Projeyi RestApi olarak .net core 3.1 platformunda geliştirdim. EF 5.0 codefirst yöntemi ile birlikte kullanılmıştır. 

endpointlist;

1 - yayına alma-kaldırma: https://localhost:44340/api/trips/1(tripid)/false, https://localhost:44340/api/trips/1(tripid)/ftrue --> HttpPut

2 - seyehat arama:https://localhost:44340/api/trips/1(fromcity)/2(tocity)

3 - katılımcı ekleme:https://localhost:44340/api/trips/1(userId)/2(tripId)

4 - seyehat ekleme: https://localhost:44340/api/trips/1(userId) 
    RequestBody: 

    {
        "RouteList" : [ 1, 2, 4,5],
        "TripDate" : "2020-11-21",
        "Explanation" : "Sefa deneme",
        "Capacity" : 4,
        "IsActive" : true

    }
