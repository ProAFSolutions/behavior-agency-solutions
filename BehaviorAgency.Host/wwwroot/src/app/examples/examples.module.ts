import { NgModule } from '@angular/core';

import { ExamplesComponent } from './examples.component';
import { DashboardModule } from './dashboard/dashboard.module';
import { ExamplesRoutingModule } from './examples-routing.module';
import { ThemeModule } from '../@theme/theme.module';
import { MiscellaneousModule } from './miscellaneous/miscellaneous.module';

const EXAMPLES_COMPONENTS = [
  ExamplesComponent,
];

@NgModule({
  imports: [
    ExamplesRoutingModule,
    ThemeModule,
    DashboardModule,
    MiscellaneousModule,
  ],
  declarations: [
    ...EXAMPLES_COMPONENTS,
  ],
})
export class ExamplesModule {
}
