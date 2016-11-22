namespace GroupTestProject.Controllers {

    export class HomeController {
        public movies;
        public MovieResource;

        public getMovies() {
            this.movies = this.MovieResource.query();
        }
        constructor(private $resource: angular.resource.IResourceService) {
            this.MovieResource = this.$resource(`/api/movies`);
            this.getMovies();
        }

    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
