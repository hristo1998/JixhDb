import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OnChanges } from '@angular/core/src/metadata/lifecycle_hooks';
import { MovieService } from '../../core/services/movie/movie.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnChanges {

  movies: any;
  category: string;

  constructor(private route: ActivatedRoute, private movieService: MovieService) { }

  ngOnInit() {
    let category = this.route.snapshot.paramMap.get('category');
    if(category){
      this.category = category;
      this.movieService.GetMoviesByCategory(category)
        .subscribe(
          res => {  
            console.log(res);          
            this.movies = res;
          }
        );
    }
    else {
      this.category = "All Movies";      
      this.movieService.GetAllMovies().subscribe(
        res => { this.movies = res; console.log(res); }
      );
    }
  }



}
