import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CoursesComponent } from './course/courses/courses.component';
import { EditCourseComponent } from './edit-course/edit-course.component';
import { AddCourseComponent } from './add-course/add-course.component';


const routes: Routes = [
  {path: 'courses', component: CoursesComponent},   
  {path:'edit-course/:id',component: EditCourseComponent},
  {path:'add-course',component: AddCourseComponent},
  {path: '', redirectTo: '/courses', pathMatch: 'full'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
