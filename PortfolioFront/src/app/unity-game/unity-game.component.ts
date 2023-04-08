import { Component } from '@angular/core';

@Component({
	selector: 'app-unity-game',
	templateUrl: './unity-game.component.html',
	styleUrls: ['./unity-game.component.sass']
})
export class UnityGameComponent {
	ngOnInit() {
		//@ts-ignore
		createUnityInstance(document.querySelector("#unity-canvas"), {
			dataUrl: "/assets/unityGame/Build/docs.data",
			frameworkUrl: "/assets/unityGame/Build/docs.framework.js",
			codeUrl: "/assets/unityGame/Build/docs.wasm",
			streamingAssetsUrl: "StreamingAssets",
			companyName: "DefaultCompany",
			productName: "PortfolioJourney",
			productVersion: "0.1"
		});
	}
}
