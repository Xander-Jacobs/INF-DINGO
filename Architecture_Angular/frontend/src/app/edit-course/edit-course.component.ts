import { Component, OnInit } from '@angular/core';
import { Course } from '../shared/course';
import { Router,ActivatedRoute } from '@angular/router';
import { DataService } from '../services/data.service';
import { FormBuilder,FormGroup } from '@angular/forms';

@Component({
  selector: 'app-edit-course',
  templateUrl: './edit-course.component.html',
  styleUrl: './edit-course.component.scss'
})

export class EditCourseComponent implements OnInit{

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
        name: [''],
        duration: [''],
        description: ['']
      });
     }

  ngOnInit(): void {
    this.route.params.subscribe(params=>{
      this.courseId=params['id'];
      this.GetCourse(this.courseId);     
    })
  }

  initializeForm(course:Course):void{
    this.courseForm=this.formBuilder.group({
      name:[course.name],
      duration:[course.duration],
      description:[course.description]
    });
  }



  onSubmit(): void {
    const formValues = this.courseForm.value;
    this.course = { ...this.course, ...formValues };
    this.dataService.UpdateCourse(this.course).subscribe(() => {
    this.router.navigate(['/courses']);
    });
  }


  GetCourse(courseId:number){
    this.dataService.GetCourse(courseId).subscribe(result=>{
      this.course=result;     
      this.initializeForm(this.course);
      });
  }
}
