using System;
using System.Collections.Generic;
using Project.Core.Scripts.Services.Logger.Base;
using UnityEditor.Compilation;

namespace Project.Core.Scripts.Utils.AssemblyUtils {
    public static class AssemblyUtil {
        private enum AssemblyType {
            AssemblyCSharp,
            AssemblyCSharpEditor,
            AssemblyCSharpEditorFirstPass,
            AssemblyCSharpFirstPass,
            AssemblyCore,
            AssemblyGame,
            AssemblyLobby,
            AssemblyGamePlay
        }

        private static AssemblyType? GetAssemblyType(string assemblyName) {
            LogService.LogError($"Assembly Name : {assemblyName}");
            return assemblyName switch {
                "Assembly-CSharp" => AssemblyType.AssemblyCSharp,
                "Assembly-CHsarp-Editor" => AssemblyType.AssemblyCSharpEditor,
                "Assembly-CHsarp-Editor-firstpass" => AssemblyType.AssemblyCSharpEditorFirstPass,
                "Assembly-CHsarp-firstpass" => AssemblyType.AssemblyCSharpFirstPass,
                "CoreAssembly" => AssemblyType.AssemblyCore,
                "GameAssembly" => AssemblyType.AssemblyGame,
                "LobbyStateAssembly" => AssemblyType.AssemblyLobby,
                "GamePlayStateAssembly" => AssemblyType.AssemblyGamePlay,
                _ => null
            };
        }

        private static void AddTypesFromAssembly(Type[] assemblyTypes, Type interfaceType, ICollection<Type> result) {
            if (assemblyTypes == null) return;
            foreach (var type in assemblyTypes) {
                if ((type != interfaceType) && (interfaceType.IsAssignableFrom(type))) {
                    result.Add(type);
                }
            }
            
        }
        
        public static List<Type> ScanTypes(Type interfaceType) {
            var assemblyToTypes = new Dictionary<AssemblyType, Type[]>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var typeList = new List<Type>();
            
            foreach (var assembly in assemblies) {
                AssemblyType? assemblyType = GetAssemblyType(assembly.GetName().Name);
                if (assemblyType != null) {
                    assemblyToTypes.Add((AssemblyType)assemblyType, assembly.GetTypes());
                }
            }
            
            assemblyToTypes.TryGetValue(AssemblyType.AssemblyCSharp, out var assemblyCharpTypes);
            AddTypesFromAssembly(assemblyCharpTypes, interfaceType, typeList);
            
            assemblyToTypes.TryGetValue(AssemblyType.AssemblyCSharpFirstPass, out var assemblyCharpFirstPassTypes);
            AddTypesFromAssembly(assemblyCharpFirstPassTypes, interfaceType, typeList);
            
            return typeList;

        }
    }
}