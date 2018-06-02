import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { PagesRoutes } from './pages.routes';
import { SharedModule } from './shared/shared.module';
import { ThemeModule } from '../@theme/theme.module';
import { PagesComponent } from './pages.component';

//Examples
import { DashboardModule } from '../examples/dashboard/dashboard.module';
import { MiscellaneousModule } from '../examples/miscellaneous/miscellaneous.module';


@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild(PagesRoutes),
    ThemeModule,
    DashboardModule,
    MiscellaneousModule,
  ],
  declarations: [
    PagesComponent
  ]
})
export class PagesModule { 


}
