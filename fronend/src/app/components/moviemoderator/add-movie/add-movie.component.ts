import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { CreateMovie } from '../../../core/models/movie/create.movie';
import { MovieService } from '../../../core/services/movie/movie.service';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.css']
})
export class AddMovieComponent implements OnInit {

  movie: CreateMovie = new CreateMovie();  
  formGroup: FormGroup;

  constructor(private movieService: MovieService,
    private router: Router) { }

  ngOnInit() {
    this.formGroup = new FormGroup({     
      Title: new FormControl('', [
        Validators.required
      ]),
      TrailerLink: new FormControl('', [
        Validators.required
      ]),
      CoverUrl: new FormControl('', [
        Validators.required
      ]),
      Duration: new FormControl('', [
        Validators.required
      ]),
      Director: new FormControl('', [
        Validators.required
      ]),
      Writers: new FormControl('', [
        Validators.required
      ]),
      CategoriesString: new FormControl('', [
        Validators.required
      ]),
      Cast: new FormControl('', [
        Validators.required
      ]),
      StoryLine: new FormControl('', [
        Validators.required
      ]),
    });
  }

  create() {
    this.movieService.create(this.movie)
      .subscribe();
      this.router.navigateByUrl('');
  }

}
