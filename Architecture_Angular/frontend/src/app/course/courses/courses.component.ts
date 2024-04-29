import { Component, OnInit } from '@angular/core';
import { Course } from '../../shared/course';
import { DataService } from '../../services/data.service';


@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {
  courses:Course[] = []

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.GetCourses()
    console.log(this.courses)
  }

  GetCourses()
  {
    this.dataService.GetCourses().subscribe(result => {
      let courseList:any[] = result
      courseList.reverse();
      courseList.forEach((element) => {
        this.courses.push(element)
      });
    })
  }

  DeleteCourse(courseId: number) {
    
    this.dataService.DeleteCourse(courseId).subscribe(() => {
      this.courses = this.courses.filter(course => course.courseId !== courseId);
    });
  }

}
