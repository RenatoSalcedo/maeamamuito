import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { NavAdminComponent } from './components/navadmin/navadmin.component';
import { HomeComponent } from './components/home/home.component';
import { GalleryComponent } from './components/gallery/gallery.component';
import { AboutComponent } from './components/about/about.component';
import { CartComponent } from './components/cart/cart.component';
import { LoginComponent } from './components/login/login.component';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        NavAdminComponent,
        GalleryComponent,
        AboutComponent,
        CartComponent,
        LoginComponent,
        HomeComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'gallery', component: GalleryComponent },
            { path: 'about', component: AboutComponent },
            { path: 'cart', component: CartComponent },
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'home' },
        ])
    ]
})
export class AppModule {
}
