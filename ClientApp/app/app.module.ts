import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { GalleryComponent } from './components/gallery/gallery.component';
import { CartComponent } from './components/cart/cart.component';
import { AboutComponent } from './components/about/about.component';
import { LoginComponent } from './admin/login/login.component';
import { CadastroComponent } from './admin/produto/cadastro.component';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        GalleryComponent,
        CartComponent,
        AboutComponent,
        LoginComponent,
        CadastroComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'gallery', component: GalleryComponent },
            { path: 'cart', component: CartComponent },
            { path: 'about', component: AboutComponent},
            { path: 'admin/login', component: LoginComponent},
            { path: 'admin/produto', component: CadastroComponent},
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModule {
}
