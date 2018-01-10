import { NgModule } from '@angular/core'
import { AuthGuard, GuestGuard, AdminGuard, ModeratorGuard, MovieModeratorGuard } from './'

@NgModule({
  imports: [],
  declarations: [],
  providers: [
    AuthGuard,
    GuestGuard,
    AdminGuard,
    ModeratorGuard,
    MovieModeratorGuard
  ]
})
export class GuardsModule { }
