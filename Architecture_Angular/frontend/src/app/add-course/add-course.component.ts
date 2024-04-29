import { Component } from '@angular/core';
import { Course } from '../shared/course';
import { Router,ActivatedRoute } from '@angular/router';
import { DataService } from '../services/data.service';
import { FormBuilder,FormGroup,Validators } from '@angular/forms';

@Component({
  selector: 'app-add-course',
  templateUrl: './add-course.component.html',
  styleUrl: './add-course.component.scss'
})
export class AddCourseComponent {

  course!:Course;
  courseId!:number;
  courseForm!:FormGroup;

  constructor(
    private formBuilder:FormBuilder,
    private dataService: DataService,
    private router: Router,
    private route:ActivatedRoute
    ) {
      this.courseForm = this.formBuilder.group({
        courseId:['0', Validators.required],
        name: ['', Validators.required],
        duration: ['', Validators.required],
        description: ['', Validators.required]
      });
     }

 

  onSubmit(): void {
    const formValues = this.courseForm.value;
    this.course = { ...this.course, ...formValues };
    console.log(this.course)
    this.dataService.AddCourse(this.course).subscribe(() => {
    this.router.navigate(['/courses']);
    });
  }

 

}
