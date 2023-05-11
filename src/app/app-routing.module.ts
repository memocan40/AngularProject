import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { ApiComponent } from './api/api.component';

const routes: Routes = [
  { path: '', component: AppComponent },
  { path: 'api', component: ApiComponent },
  // Weitere Routen...
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
