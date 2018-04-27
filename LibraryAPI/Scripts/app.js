angular.
    module("LibraryApp", [])
    .controller("mainController", ["$scope", "$http", ($scope, $http) => {

        $scope.books = [];

        const searchForBooks = () => {
            let searchUrl = "/api/search"
            if ($scope.searchParam) {
                searchUrl += "?title=" + $scope.searchParam
            }

            $http({
                method: "GET",
                url: searchUrl
            }).then(resp => {
                $scope.books = resp.data;
            })
        }

        $scope.searchBooks = () => {
            searchForBooks();
        }

        $scope.checkOutBook = (book) => {
            //PUT
            $http({
                method: "PUT",
                url: "/api/checkout/" + book.Id,
                data: {
                    email: $scope.email
                }
            }).then(resp => {

                console.log(resp.data)
                book.IsCheckedOut = true;
                book.DueBackDate = resp.data.DueBackDate;
                book.Message = resp.data.Message;
            })
        }

        var init = () => {
            $scope.welcomeMessage = "Welcome to the Smallest Library EVER!!!!"
            searchForBooks();
        }


        init();
    }])




        $http({
            method: "GET",
            url: "api/books"
        }).then(resp => {
            console.log(resp.data);
            $scope.books = resp.data;
            })

        $scope.search = () => {
            $http({
                method: "GET",
                url: "api/searchbook"
            }).then(response => {
                $scope.books = response.data
                $scope.BookSearch = []
            })
        }
    }


    }]);