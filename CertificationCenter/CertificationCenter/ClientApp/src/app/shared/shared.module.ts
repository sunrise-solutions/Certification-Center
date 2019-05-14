import { environment } from './../../environments/environment';
//import { FileUploaderDirective } from './file-uploader/file-uploader.directive';
import { InjectionToken, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

//import { CarouselModule } from 'ngx-bootstrap/carousel';
//import { ModalModule } from 'ngx-bootstrap';

// import { BackgroundImageComponent } from './background-image/background-image.component';
// import { BreadcrumbsComponent } from './breadcrumbs/breadcrumbs.component';
// import { BreadcrumbsDirective } from './breadcrumbs/breadcrumbs.directive';
// import { ColorRadioButtonDirective } from './color-radio-button/color-radio-button.directive';
// import { FillContainerComponent } from './fill-container/fill-container.component';
// import { PercentageBarRatingComponent } from './percentage-bar-rating/percentage-bar-rating.component';
// import { PreloadImageComponent } from './preload-image/preload-image.component';
// import { PreloadAvatarComponent } from './preload-avatar/preload-avatar.component';
// import { SearchBarComponent } from './search-bar/search-bar.component';
// import { StarRatingComponent } from './star-rating/star-rating.component';
// import { StylishCarouselComponent } from './stylish-carousel/stylish-carousel.component';
 import { OAuthModule } from 'angular-oauth2-oidc';
// import { FileUploadModule } from 'ng2-file-upload';
// import { WorkWithTextService } from './services/work-with-text.service';
// import { FullscreenImageModalComponent } from './fullscreen-image-modal/fullscreen-image-modal.component';

export const API_BASE_URL = new InjectionToken<string>('http://localhost:4200');

@NgModule({
  declarations: [
    // Shared components
    // BackgroundImageComponent,
    // BreadcrumbsComponent,
    // BreadcrumbsDirective,
    // ColorRadioButtonDirective,
    // FillContainerComponent,
    // PercentageBarRatingComponent,
    // PreloadImageComponent,
    // PreloadAvatarComponent,
    // SearchBarComponent,
    // StarRatingComponent,
    // StylishCarouselComponent,
    // FileUploaderDirective,
    // FullscreenImageModalComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    // ModalModule.forRoot(),
    // CarouselModule.forRoot(),
    OAuthModule.forRoot({
      resourceServer: {
        allowedUrls: [
          `${environment.BASE_URL}`
        ],
        sendAccessToken: true
      }
    }),
    //FileUploadModule
  ],
  exports: [
    // Shared components
    // BackgroundImageComponent,
    // BreadcrumbsComponent,
    // BreadcrumbsDirective,
    // ColorRadioButtonDirective,
    // FillContainerComponent,
    // PercentageBarRatingComponent,
    // PreloadImageComponent,
    // PreloadAvatarComponent,
    // SearchBarComponent,
    // StarRatingComponent,
    // FullscreenImageModalComponent,
    // StylishCarouselComponent,
    // Re-export these modules to prevent repeated imports (see: https://angular.io/guide/ngmodule#re-exporting-other-modules)
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    OAuthModule,
    // shared Modules
    //FileUploadModule,
    //FileUploaderDirective
  ],
  //providers: [WorkWithTextService]
})
export class SharedModule { }
