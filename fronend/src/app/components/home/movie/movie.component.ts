import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../../core/services/movie/movie.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {

  movie: any;

  constructor(private movieService: MovieService,
    private route: ActivatedRoute) { }

  ngOnInit() {    
    let id = this.route.snapshot.paramMap.get('id');
    this.movieService.GetMoviesById(id)
      .subscribe(
        res => {this.movie = res; console.log(res)});
  }

}
