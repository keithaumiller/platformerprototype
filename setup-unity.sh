#!/bin/bash

# Unity Installation Helper Script
# This script helps prepare for Unity installation when run locally

echo "🎮 Unity Installation Helper"
echo "============================="
echo

echo "Since we're in a dev container environment, Unity needs to be installed locally."
echo "Here's what you need to do:"
echo

echo "1. 📥 Download and Install Unity Hub:"
echo "   - Visit: https://unity3d.com/get-unity/download"
echo "   - Download Unity Hub for your operating system"
echo "   - Install Unity Hub"
echo

echo "2. 🔧 Install Unity Editor:"
echo "   - Open Unity Hub"
echo "   - Go to 'Installs' tab"
echo "   - Click 'Install Editor'"
echo "   - Choose Unity 2022.3.x LTS (recommended) or Unity 6 (latest)"
echo "   - Select modules needed:"
echo "     ✓ WebGL Build Support (for web deployment)"
echo "     ✓ Android Build Support (for mobile deployment)"
echo "     ✓ iOS Build Support (if on Mac, for mobile deployment)"
echo

echo "3. 🎯 Open This Project:"
echo "   - In Unity Hub, click 'Add' (or 'Open')"
echo "   - Navigate to this folder: $(pwd)"
echo "   - Select this folder as the project root"
echo "   - Unity will import the project and generate necessary files"
echo

echo "4. 🧰 VS Code Extensions (Already Installed):"
echo "   ✓ C# extension (for IntelliSense)"
echo "   ✓ Unity Debug extension"
echo "   ✓ Unity Tools extension"
echo

echo "5. 🚀 Start Developing:"
echo "   - Create your first scene in Unity"
echo "   - Add the PlayerController script to a GameObject"
echo "   - Test your movement and jumping"
echo "   - Follow the GETTING_STARTED.md guide"
echo

echo "🔍 Project Files Ready:"
echo "   📁 Assets/Scripts/ - Your C# scripts"
echo "   📁 ProjectSettings/ - Unity configuration"
echo "   📁 Packages/ - Package dependencies"
echo "   📄 .gitignore - Git ignore for Unity projects"
echo

echo "💡 Need help? Check:"
echo "   - README.md - Project overview and setup"
echo "   - GETTING_STARTED.md - Step-by-step first steps"
echo "   - DEVELOPMENT_PLAN.md - Full development roadmap"
echo

read -p "Press Enter to continue..."