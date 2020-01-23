import { Component, OnInit } from '@angular/core';
import { ResultCourses, VideoService } from '../../services/video.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';
import * as moment from 'moment';
import { User, CustomUser } from 'src/app/auth/models/user';
import { AuthService } from 'src/app/auth/services/auth.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';

@Component({
  selector: 'app-search-courses',
  templateUrl: './search-courses.component.html',
  styleUrls: ['./search-courses.component.scss']
})
export class SearchCoursesComponent implements OnInit {

  resultCourses: ResultCourses[] = [];
  searchForm: FormGroup;
  parameter: string;
  videoService: VideoService;
  isAuthenticated: boolean;
  user: CustomUser;

  constructor(private service: VideoService, route: ActivatedRoute, fb: FormBuilder, private authService: AuthService) {
      this.searchForm = fb.group({
        name: [''],
        description: ['Any'],
        published: ['Any'],
        price: ['Any'],
      });
      this.videoService = service;
    }

    onSubmit() {
      if (this.searchForm.valid) {
        console.log('Search start..');

        const dataForm = this.searchForm.value;

        const searchCourses =  new SearchCourses();
        searchCourses.Name = dataForm.name;
        searchCourses.Description = dataForm.description;
        searchCourses.Price = dataForm.price;

        this.service.searchCourses(searchCourses, this.user).subscribe(data => {
        this.resultCourses = data;
        this.videoService.resultSubject.next(this.resultCourses);
        console.log('Search completed!');
        });
      }
    }

  ngOnInit() {
    this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag);
    this.authService.user$.subscribe((user) => this.user = user as CustomUser);
  }

}


export class SearchCourses {
  Id: string;
  Name: string;
  Description: string;
  Price: number;
}
