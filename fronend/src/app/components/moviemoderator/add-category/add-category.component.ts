import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { CreateCategory } from '../../../core/models/movie/create.category';
import { MovieService } from '../../../core/services/movie/movie.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {

  category: CreateCategory;
  formGroup: FormGroup;

  constructor(private movieService: MovieService,
    private router: Router) { }

  ngOnInit() {
    this.category = new CreateCategory();
    
    this.formGroup = new FormGroup({     
      Name: new FormControl('', [
        Validators.required
      ]),
      Description: new FormControl('', [
        Validators.required
      ])
    });
  }

  create() {
    this.movieService.AddCategory(this.category)
      .subscribe();
    this.router.navigateByUrl('');
  }

}
