import { Injectable } from '@angular/core';
import { HttpService } from '../auth/http.service';
import { Observable } from 'rxjs/Observable';
import { CreateMovie } from '../../models/movie/create.movie';
import { CreateCategory } from '../../models/movie/create.category';

@Injectable()
export class MovieService {

    constructor(private httpService: HttpService) { }

    create(movie: CreateMovie): Observable<any> {
        return this.httpService.post('movies', movie);
    }

    AddCategory(category: CreateCategory): Observable<any> {
        return this.httpService.post('categories', category);
    }

    GetAllCategories(): Observable<any> {
        return this.httpService.get('categories');
    }

    GetMoviesByCategory(category: string): Observable<any> {
        return this.httpService.get(`movies?categoryName=${category}`);
    }

    GetAllMovies(): Observable<any> {
        return this.httpService.get(`movies`);
    }

    GetMoviesById(id: string): Observable<any> {
        return this.httpService.get(`movies/${id}`);
    }
}