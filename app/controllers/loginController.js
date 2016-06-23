// "use strict";

// GroceryRecipe.controller('loginController', [
// 	'$http', 
// 	'$scope',
// 	"$location",
// 	'AuthFactory',

// 	function ($http, $scope, $location, authFactory) {

// 		$scope.facebookOauth = function () {
// 			OAuth.initialize('Snn4UErqpYBOPxTTtmCwZVN2ncc');

// 			OAuth.popup('facebook').done(function(result) {
// 			    console.log(result)

// 				result.me().done(function(data) {
// 				    // do something with `data`, e.g. print data.name
// 				    console.log(data);

// 				    $http({
// 				    	url: "http://localhost:64540/api/foodeater",
// 				    	method: "POST",
// 				    	data: JSON.stringify({
// 				    		FirstName : data.FirstName,
// 				    		LastName : data.LastName,
// 				    		Username: data.Username,
// 				    		Email: data.Email
// 				    	})
// 				    }).then(
// 				    response => {
// 				    	let theFoodie = response.data[0];
// 				    	authFactory.setUser(theFoodie);
// 				    	console.log("resolve fired", theFoodie);
// 				    },
// 				    response => {
// 				    	console.log("reject fired", response);

// 				    	// foodie has already been created
// 				    	if (response.status === 409) {
// 				    		$http
// 				    			.get(`http://localhost:64540/foodeater?Username=${data.Username}`)
// 				    			.then(
// 				    				response => {
// 				    					let theFoodie = response.data[0];
// 				    					console.log("Found the Foodie", theFoodie);
// 				    					authFactory.setUser(theFoodie)
// 				    				},
// 				    				response => console.log("Could not find that Foodie", response)
// 				    			)
// 				    	}

// 				    }
// 				    )
// 				})
// 			});
// 		};
// 	}
// ]);