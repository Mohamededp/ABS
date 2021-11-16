// tracking box
var test = null;
var test2 = null;
var test3 = null;
var test4 = null;
var test5 = null;
var test6 = null;
var test7 = null;
var b = null;
var flag = 0;
var data = null;

async function myFunction() {
        b = localStorage.getItem("shipid");
        let response = await fetch("https://absegy.org/ABSAPI/api/Free/V2/GetShipmentHistory/" + b);
        let data = await response.json();
        buildTable(data.HistoryData);
        test = (data.ShipmentInfo.StatusName);
        test2 = (data.ShipmentInfo.PickupDate);
        test3 = (data.ShipmentInfo.RecipientName);
        test4 = (data.ShipmentInfo.ConsigneeName);
        test5 = (data.ShipmentInfo.ToCity);
        //var test70 = (data.ShipmentInfo.Data9);
        test6 = (data.ShipmentInfo.FromCity);
        test7 = (data.ShipmentInfo.ToAddress);
        //test10 = (data.HistoryData[data.HistoryData.length - 1].ActionDate);
        document.getElementById('AWB').innerHTML = b;
        document.getElementById('Status').innerHTML = test;
        document.getElementById('PickupDate').innerHTML = test2;
        document.getElementById('RecipName').innerHTML = test3;
        document.getElementById('ConsigneeName').innerHTML = test4;
        document.getElementById('ToCity').innerHTML = test5;
        document.getElementById('FromCity').innerHTML = test6;
        document.getElementById('ToAdd').innerHTML = test7;
        return data;
    }
function valueSender() {
    var shipid = document.getElementById('shipmentid').value;
    localStorage.setItem("shipid", shipid);
}



function buildTable(tabledata) {
    var table = document.getElementById('myTable');

    for (var i = 0; i < tabledata.length; i++) {
        var row = `<tr><td>${tabledata[i].ActionDate}</td><td>${tabledata[i].RecipientName}</td><td>${tabledata[i].Status}</td><td>${tabledata[i].Reason}</td><td>${tabledata[i].Notes}</td></tr>`;
        table.innerHTML += row;
    }
}

function clear() {
    document.getElementById("shipmentid").value = "";
}




// function initMap()
// {
//     var location = {lat:29.962115 , lng:31.250282};
//     var map=new google.maps.Map(document.getElementById("map"),{
//         zoom:4,
//         center:location
//     });
//     var marker = new google.maps.Marker({
//         position:location,
//         map:map
//     });
// }


// function initMap() {
//     const myLatLng = { lat: 29.962115, lng: 31.250282 };
//     const map = new google.maps.Map(document.getElementById("map"), {
//       zoom: 4,
//       center: myLatLng,
//     });
  
//     new google.maps.Marker({
//       position: myLatLng,
//       map,
//       title: "Hello World!",
//     });
//   }
